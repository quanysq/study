using EumnSample;

// 1. 获取枚举的描述
HttpMethodType httpMethodType = HttpMethodType.GET;
string getMethodDesc = httpMethodType.ToDescription();
Console.WriteLine(getMethodDesc);

// 2. 根据描述获取相应的枚举
string postMethodDesc = "保存数据";
HttpMethodType postMethodType = postMethodDesc.GetEnumByDescription<HttpMethodType>();
Console.WriteLine(postMethodType.ToString());

// 3. 根据枚举名称获取相应的枚举
string putMethodStr = "PUT";
HttpMethodType putMethodType = putMethodStr.ToEnum<HttpMethodType>();
Console.WriteLine(putMethodType.ToString());

// 4. 根据枚举的值获取相应的枚举
int delMethodValue = 4;
HttpMethodType delMethodType = delMethodValue.ToEnum<HttpMethodType>();
Console.WriteLine(delMethodType.ToString());

