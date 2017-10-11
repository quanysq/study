package com.bdna.c2.activitiui.util;

import org.apache.http.client.methods.CloseableHttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;
import org.apache.http.util.EntityUtils;

import com.fasterxml.jackson.databind.ObjectMapper;

public class HttpClientUtil {
	public static <T> T httpGet(String url, String basicAuth, Class<T> responseType, Boolean isNeedJoinBasicUrl) throws Exception {
		T t = responseType.newInstance();
		CloseableHttpClient httpClient = HttpClients.createDefault();
		try {
			String fullUrl = buildHttpClientUrl(url, isNeedJoinBasicUrl);
			
			HttpGet httpGet = new HttpGet(fullUrl);
			httpGet.addHeader("Authorization", basicAuth);
			CloseableHttpResponse httpResponse = httpClient.execute(httpGet);
			try {
				System.out.println(httpResponse.getStatusLine());
				int statusCode = httpResponse.getStatusLine().getStatusCode();
				if (statusCode == 200) {
					try {
						String httpResult = EntityUtils.toString(httpResponse.getEntity());
						System.out.println(httpResult);
						ObjectMapper mapper = new ObjectMapper();
						t = mapper.readValue(httpResult, responseType);
						return t;
					} catch (Exception e) {
						System.out.println("Error");
						e.printStackTrace();
					}
				}
			} finally {
				httpResponse.close();
			}
		} finally {
			httpClient.close();
		}
		return t;
	}
	
	private static String buildHttpClientUrl(String url, Boolean isNeedJoinBasicUrl) {
		String fullUrl = "";
		if (isNeedJoinBasicUrl) {
			String basicUrl = PropertyUtil.getProperty("restfulBaseUrl");
			fullUrl = basicUrl + url;
		} else {
			fullUrl = url;
		}
		return fullUrl;
	}
}
