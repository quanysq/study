Console.WriteLine("开始下载人邮社网站");
string destFile = @"D:\Work\study\TestProject_VS2022\NetCore\ASP.NETCore技术内幕与项目实战\02\ptpress.html";
int i1 = await DownloadAsync("https://www.ptpress.com.cn", destFile);
Console.WriteLine($"下载完成，长度{i1}");

async Task<int> DownloadAsync(string url, string destFilePath)
{
    using HttpClient httpClient= new HttpClient();
    string body = await httpClient.GetStringAsync(url);
    await File.WriteAllTextAsync(destFilePath, body);
    return body.Length;
}
