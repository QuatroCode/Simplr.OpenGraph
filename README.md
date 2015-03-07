# Simplr.OpenGraph

OpenGraph tags generator for .NET. Built according to [OpenGraph spec found here](http://ogp.me/)

## Usage

Helper class that generates tags for OpenGraph has two main methods:
```C#
OGHelper.GetMetadata<T>(IOGType<T> metadata)
OGHelper.GetMetadata<T>(OGMetadata metadata, IOGType<T> contentMetadata)
```

Both return string filled with generated meta tags.

## Example

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