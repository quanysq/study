<!DOCTYPE html>
<html>
	<title>Get Request Type</title>
	<head>
	</head>
	<body>
		<b>Request Type: </b><%=Request.ServerVariables("REQUEST_METHOD") %>
		<hr />
		<b>Request IP:</b> <%=GetRequestIP() %>
		<hr />
		<b>Request Body:</b>
		<% 
			WriteFile "==========================Begin==========================="
			WriteFile now
			if Request.ServerVariables("REQUEST_METHOD") = "POST" And Request.TotalBytes > 0 AND Request.TotalBytes <= 200000 then
				Dim postBody
				postBody = BytesToStr(Request.BinaryRead(Request.TotalBytes))
				WriteFile "Request Body:" & "[" & strContent & "]"
				Response.Write postBody
			end if
		%>
		<hr />
		<b>Request:</b>
		<br />
		<%
			WriteFile "All request serverVariables: ["
			For Each n In Request.ServerVariables
				dim strContent
				strContent = n & " = " & Request.ServerVariables(n)
				WriteFile strContent
				Response.Write strContent & "<br />"
			Next
			WriteFile "]"
			WriteFile "==========================End==========================="
			WriteFile ""
		%>
		
		<%
		Function GetRequestIP()
			dim userIP 
			userIP = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
			if userIP = "" then 
				userIP = Request.ServerVariables("REMOTE_ADDR")
			end if
			GetRequestIP = userIP
		End Function 
		
		Sub WriteFile(strContent)
			' strContent Ð´ÈëµÄÄÚÈÝ
			On Error Resume Next
			dim LogFile
			LogFile = Server.MapPath("/logs/" & year(now)& month(now) & day(now) & ".log")
			
			Set objFSO = Server.CreateObject("Scripting.FileSystemObject")
			
			if not objFSO.FileExists(LogFile) then
				objFSO.CreateTextFile LogFile
			end if
			
			Set objWriteText = objFSO.OpenTextFile(LogFile,8,True)
			objWriteText.WriteLine(strContent)
			Set objWriteText = Nothing
			Set objFSO = Nothing
			
			Select Case Err
               Case 424 Response.Write "The log file does not exist."
               Case Else Response.Write Err.Description
			End Select
		End Sub
		
		Function BytesToStr(bytes)
			Dim Stream
			Set Stream = Server.CreateObject("Adodb.Stream")
				Stream.Type = 1 'adTypeBinary
				Stream.Open
				Stream.Write bytes
				Stream.Position = 0
				Stream.Type = 2 'adTypeText
				Stream.Charset = "utf-8"
				BytesToStr = Stream.ReadText
				Stream.Close
			Set Stream = Nothing
		End Function

		%>
	</body>
	
	
</html>