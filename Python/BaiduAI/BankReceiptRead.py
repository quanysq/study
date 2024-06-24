# 百度AI 识别银行电子回单文件数据

import requests
import base64
import urllib

# 个人账号
# API_KEY = "pe3esXC4xt7RpOQemYtdMGwk"
# SECRET_KEY = "Tnksvc1GUgoFYpUqI83z9Naxu6g6Piju"

# 公司账号
API_KEY = "YnnlievKX3gpRjmO0q7apfyP"
SECRET_KEY = "xBvQu8qQSG7MqleXc2GiUXux8XxrLaFV"

def main():
    token = get_access_token()
    url = "https://aip.baidubce.com/rest/2.0/ocr/v1/bank_receipt_new?access_token=" + token
    # pdf_file = "D:\Work\GaoShen\doc\自记帐\开发\银行电子回单测试表.pdf";
    # pdf_file = "D:\Learn\study\Python\BaiduAI\page_1_1.jpg"
    pdf_file = "D:\Work\GaoShen\doc\自记帐\开发\百度 AI 结果\银行回单截图\page_14_1.jpg"
    pdf_code = get_file_content_as_base64(pdf_file)
    print(pdf_code)
    # payload = {"pdf_file": pdf_code, "pdf_file_num": "1-2"}
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
