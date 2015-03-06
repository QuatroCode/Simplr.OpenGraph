using Simplr.OpenGraph.Contracts;
using Simplr.OpenGraph.Enums;
using Simplr.OpenGraph.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Simplr.OpenGraph.Helpers
{
    public static class OGHelper
    {
        public static string GetMetadata<T>(IOGType<T> metadata)
        {
            if (metadata == null)
            {
                return null;
            }
            var metadataKeyValue = GetKeyValue(metadata);
            return SetMetaProperties(metadataKeyValue);
        }
        public static string GetMetadata<T>(OGMetadata metadata, IOGType<T> objectClass)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }
            if (metadata.Title == null)
            {
                throw new ArgumentNullException("Title");
            }
            if (metadata.Url == null)
            {
                throw new ArgumentNullException("Url");
            }
            if (metadata.Image == null)
            {
                throw new ArgumentNullException("Image");
            }
            string result = null;
            result += string.Format("<title>{0}</title>", metadata.Title);
            result += SetMetaProperties(ReplaceValue(metadata, objectClass));

            return result;
        }

        private static IList<OGKeyValue> ReplaceValue<T>(OGMetadata metadata, IOGType<T> objectClass, string name = "type")
        {
            var result = new List<OGKeyValue>();

            var metadataKeyValue = GetKeyValue(metadata);
            var objectClassKeyValue = GetKeyValue(objectClass);

            var itemOld = metadataKeyValue.FirstOrDefault(x => x.Name == name);
            var itemNew = objectClassKeyValue.FirstOrDefault(x => x.Name == name);
            if (itemOld != null || itemNew != null)
            {
                //replace Content value
                itemOld.Content = itemNew.Content;
                //delete old item
                objectClassKeyValue.Remove(itemNew);
            }
            result.AddRange(metadataKeyValue);
            result.AddRange(objectClassKeyValue);

            return result;
        }
        private static IList<OGKeyValue> GetKeyValue<T>(IOGType<T> data)
        {
            var result = new List<OGKeyValue>();
            var baseType = data.GetType().GetTypeInfo().BaseType;
            var properties = baseType.GetRuntimeProperties();

            if (baseType == typeof(object))
            {
                properties = data.GetType().GetTypeInfo().DeclaredProperties;
            }
            foreach (var property in properties)
            {
                var name = property.Name;
                var value = property.GetValue(data);

                if (value == null)
                {
                    continue;
                }

                var valueType = value.GetType();
                if (valueType.Name != "String" && valueType.Name != "Uri")
                {
                    if (valueType.Name == "List`1")
                    {
                        foreach (var item in value as IList)
                        {
                            var itemType = item.GetType();
                            if (itemType.Name != "String")
                            {
                                var itemBaseType = itemType.GetTypeInfo().BaseType;
                                result.AddRange(ExtractKeyValueFromProperties(itemBaseType.GetRuntimeProperties(), item, name.ToLower()));

                                result.AddRange(ExtractKeyValueFromProperties(itemType.GetTypeInfo().DeclaredProperties, item, name.ToLower()));
                            }
                            else
                            {
                                result.Add(new OGKeyValue()
                                {
                                    Name = name.AddSymbolBeforeUpperCase(':').ToLower(),
                                    Content = item.ToString()
                                });
                            }
                        }
                        continue;
                    }
                    if (valueType == typeof(OGDeterminer))
                    {
                        var enumValue = value.ToString();
                        if (OGDeterminer.Blank == value as OGDeterminer?)
                        {
                            enumValue = "";
                        }
                        result.Add(new OGKeyValue()
                        {
                            Name = name.ToLower(),
                            Content = enumValue.ToLower()
                        });
                        continue;
                    }
                    if (name == "Type")
                    {
                        result.Add(new OGKeyValue()
                        {
                            Name = name.ToLower(),
                            Content = ChangeText(value.ToString())
                        });
                        continue;
                    }
                    result.AddRange(ExtractKeyValueFromProperties(valueType.GetTypeInfo().DeclaredProperties, value, name.ToLower()));
                    continue;
                }
                result.Add(new OGKeyValue()
                {
                    Name = name.AddSymbolBeforeUpperCase('_').ToLower(),
                    Content = value.ToString()
                });
            }
            return result;
        }
        private static string SetMetaProperties(IList<OGKeyValue> data)
        {
            string result = null;
            foreach (var item in data)
            {
                result += string.Format("<meta property=\"og:{0}\" content=\"{1}\" />", item.Name, item.Content);
            }
            return result;
        }

        private static IList<OGKeyValue> ExtractKeyValueFromProperties(IEnumerable<PropertyInfo> properties, object valueObject, string originalName)
        {
            var result = new List<OGKeyValue>();
            foreach (var property in properties)
            {
                var separator = ":";
                var name = property.Name.AddSymbolBeforeUpperCase('_').ToLower();
                var value = property.GetValue(valueObject);
                if (value == null || value as int? == 0)
                {
                    continue;
                }
                if (name == "type")
                {
                    continue;
                }
                if (name == "url")
                {
                    separator = "";
                    name = "";
                }

                var valueType = value.GetType();
                if (valueType.Name != "String" && valueType.Name != "Uri" && valueType.Name != "Int32" && valueType.Name != "DateTime")
                {
                    if (valueType.Name == "List`1")
                    {
                        foreach (var item in value as IList)
                        {
                            var itemType = item.GetType();
                            if (itemType.Name != "String")
                            {
                                var itemBaseType = itemType.GetTypeInfo().BaseType;
                                result.AddRange(ExtractKeyValueFromProperties(itemBaseType.GetRuntimeProperties(), item, name.ToLower()));

                                result.AddRange(ExtractKeyValueFromProperties(itemType.GetTypeInfo().DeclaredProperties, item, name.ToLower()));
                            }
                            else
                            {
                                result.Add(new OGKeyValue()
                                {
                                    Name = name.AddSymbolBeforeUpperCase(':').ToLower(),
                                    Content = item.ToString()
                                });
                            }
                        }
                        continue;
                    }
                    result.AddRange(ExtractKeyValueFromProperties(valueType.GetTypeInfo().DeclaredProperties, value, name.ToLower()));
                    continue;
                }
                else
                {
                    result.Add(new OGKeyValue()
                    {
                        Name = string.Format("{0}{1}{2}", originalName, separator, name),
                        Content = value.ToString()
                    });
                }
            }
            return result;
        }

        /// <summary>
        /// Add dot instead of underscore and add underscore before UpperCase
        /// </summary>
        /// <param name="text">Text which have to be changed</param>
        /// <returns>Changed string</returns>
        public static string ChangeText(string text)
        {
            var changeUnderscoreToDot = text.AddDotInsteadOfUnderscore();
            var addUnderscoreBeforeUpperCase = changeUnderscoreToDot.AddSymbolBeforeUpperCase('_');
            return addUnderscoreBeforeUpperCase.ToLower();
        }
        private static string AddSymbolBeforeUpperCase(this string text, char symbol)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != '.')
                {
                    newText.Append(symbol);
                }
                newText.Append(text[i]);
            }
            return newText.ToString();
        }
        private static string AddDotInsteadOfUnderscore(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == '_')
                {
                    newText.Append('.');
                }
                else
                {
                    newText.Append(text[i]);
                }
            }
            return newText.ToString();
        }
    }
}
