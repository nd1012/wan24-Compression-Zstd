# wan24-Compression-Zstd

This library adopts 
[ZstdSharp.Port](https://github.com/oleg-st/ZstdSharp) 
to [wan24-Compression](https://www.nuget.org/packages/wan24-Compression/) and 
extends the `wan24-Compression` library with these algorithms:

| Algorithm | ID | Name |
| --- | --- | --- |
| zstd | 3 | zstd |

## How to get it

This library is available as 
[NuGet package](https://www.nuget.org/packages/wan24-Compression-Zstd/).

## Usage

In case you don't use the `wan24-Core` bootstrapper logic, you need to 
initialize the LZ4 extension first, before you can use it:

```cs
wan24.Compression.Zstd.Bootstrapper.Boot();
```

This will register the compression algorithm to the `wan24-Compression` 
library.
