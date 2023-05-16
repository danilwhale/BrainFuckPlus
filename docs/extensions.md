# Extensions
## Installing
To install extension, you need create `ext` folder inside root of BF+ and put extension you found (.dll, not .zip)
## Creating
To create extension, you must create .NET 6 Class Library project first. After you create project, you need add download BF+ source code and add reference to BF+ project (because BF+ distributes only in .exe way, without .dll to include). You can check [BrainFkPlus.Extension source code](https://github.com/localwhale20/BrainFuckPlus/tree/main/src/BrainFkPlus.Extension) to see example of extension. When you complete writing extension, build it and then install like in #Installing chapter