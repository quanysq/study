#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

#添加一个基于asp.net6.0的镜像，命名为base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app 	#切换工作目录下
EXPOSE 80		#设置对外端口为80和443
EXPOSE 443

#拉取.net镜像的.net core6.0的sdk 來构建我们这个项目,命名为build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApiWithDocker.csproj", "./"]
RUN dotnet restore "./WebApiWithDocker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebApiWithDocker.csproj" -c Release -o /app/build

#项目构建完成后需要打包发布，继续使用.net core6.0的sdk來发布,也就是上面命名的build，生成可执行的dll文件
FROM build AS publish
RUN dotnet publish "WebApiWithDocker.csproj" -c Release -o /app/publish

#切换会第一阶段的base镜像，然后使用COPY命令把构建发布完成的所有文件都复制到工作目录，最后给Docker设置一个启动点，通过dotnet命令启动项目
FROM base AS final 								#切换会第一阶段的base镜像
WORKDIR /app									#切换到工作目录
COPY --from=publish /app/publish .				#使用COPY命令把构建发布完成的所有文件都复制到工作目录
ENTRYPOINT ["dotnet", "WebApiWithDocker.dll"]	#给Docker设置一个启动点，通过dotnet命令启动项目