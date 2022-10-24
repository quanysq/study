// 将global修饰符添加到任何using关键字前，这样通过using语句引入的命名空间就可以应用到这个项目的所有源代码中
// 使用全局using指令，项目中的其他C#文件不需要再去单独声明这些命名空间的using语
global using Microsoft.Data.Sqlite;
global using System.Text.Json;
