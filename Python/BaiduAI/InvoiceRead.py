# 百度AI 增值税发票识别

import requests
import base64
import urllib

API_KEY = "pe3esXC4xt7RpOQemYtdMGwk"
SECRET_KEY = "Tnksvc1GUgoFYpUqI83z9Naxu6g6Piju"


def main():
    token = get_access_token()
    url = "https://aip.baidubce.com/rest/2.0/ocr/v1/vat_invoice?access_token=" + token
    # pdf_file = "D:\Work\GaoShen\发票.pdf";
    # pdf_file = "D:\Work\GaoShen\doc\百度AI\餐饮发票.pdf";
    # pdf_file = "D:\Work\GaoShen\doc\百度AI\服务费.pdf";
    # pdf_file = "D:\Work\GaoShen\doc\百度AI\收入.png";
    # pdf_file = "D:\Work\GaoShen\doc\百度AI\收入-红冲.png";
    pdf_file = "D:\Work\GaoShen\doc\百度AI\测试新.png";
    pdf_code = get_file_content_as_base64(pdf_file)
    print(pdf_code)
    # payload = {"pdf_file": pdf_code}
    payload = {"image": pdf_code}
    headers = {
        'Content-Type': 'application/x-www-form-urlencoded',
        'Accept': 'application/json'
    }

    response = requests.request("POST", url, headers=headers, data=payload)

    print(response.text)


def get_file_content_as_base64(path, urlencoded=False):
    """
    获取文件base64编码
    :param path: 文件路径
    :param urlencoded: 是否对结果进行urlencoded
    :return: base64编码信息
    """
    with open(path, "rb") as f:
        content = base64.b64encode(f.read()).decode("utf-8")
        if urlencoded:
            content = urllib.parse.quote_plus(content)

    return content


def get_access_token():
    """
    使用 AK，SK 生成鉴权签名（Access Token）
    :return: access_token，或是None(如果错误)
    """
    url = "https://aip.baidubce.com/oauth/2.0/token"
    params = {"grant_type": "client_credentials", "client_id": API_KEY, "client_secret": SECRET_KEY}

    result = str(requests.post(url, params=params).json().get("access_token"))
    print("result: " + result)
    return result


if __name__ == '__main__':
    main()
