using AESSample;

Console.WriteLine("请输入待加密数据：");

string data = Console.ReadLine();

string encryptData = EncryptUtil.AESEncode(data, null);

Console.WriteLine("");
Console.WriteLine($"AES 加密后数据：{encryptData}");

string decodeData = EncryptUtil.AESDecode(encryptData, null);
Console.WriteLine("");
Console.WriteLine($"AES 加密后的密文解密后是：{decodeData}");
