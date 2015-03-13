# Simplr.OpenGraph

OpenGraph tags generator for .NET. Built according to [OpenGraph spec found here](http://ogp.me/)

## NuGet package

You can find [NuGet package here](https://www.nuget.org/packages/Simplr.OpenGraph/) or install it via package manager console:

```
Install-Package Simplr.OpenGraph
```

## Usage

Helper class that generates tags for OpenGraph has two main methods:
```C#
OGHelper.GetMetadata<T>(IOGType<T> metadata)
OGHelper.GetMetadata<T>(OGMetadata metadata, IOGType<T> contentMetadata)
```

Both return string with generated meta tags.

## Basic Example

1. Create page defining metadata object:

    ```C#
    var metadata = new OGMetadata() {
        Title = "My cool page title",
        Url = new Uri("https://mypage.buzz"),
        Description = "My page that has a cool title and even cooler site name!",
        SiteName = "Cool page"
    };
    ```

    Objects can be filled fully or partially.

2. Call helper method to generate meta tags

    ```C#
    string tags = OGHelper.GetMetadata(metadata);
    ```

3. Add meta tags to your HTML -> HEAD website

4. You can test if it works in [Facebook's debug tool here](https://developers.facebook.com/tools/debug/og/object/)

## Specific page type example

Some of our pages have more specific data, e.g. they represent Music Song, Music Album, Profile, Book, etc.

If you want to add that specific metadata in addition to basic one, create a [global type](http://ogp.me/#types) object from provided models or create your own (section bellow)

```C#
var metadata = new OGMetadata() {
    Title = "My cool page title",
    Url = new Uri("https://mypage.buzz"),
    Description = "My page that has a cool title and even cooler site name!",
    SiteName = "Cool page"
};

var customMetadata = new OGProfile(){
    FirstName = "John",
    LastName = "Smith",
    Username = "johnysmith"
}

string tags = OGHelper.GetMetadata(metadata, customMetadata);

```

## Custom type example

If your page data does not fall into any of global types, you can create custom ones.

To do that, simply create your type and inherit a global type or implement IOGType interface and define your own properties.

### Custom type example

```C#
class MyPageObj : IOGType {
    public string Type {
        get { return "MyType"; }
    }

    public string MyProperty {
        get { return "MyPropertyValue"; }
    }
}
```

And use it like in "Specific page type example".