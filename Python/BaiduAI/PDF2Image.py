# 将 PDF 转换成图片, 并等高拆分每一页图片为三张图片

# from PyPDF2 import PdfReader
# from PIL import Image
#
# # 打开 PDF 文件
# pdf_file = 'D:\Work\GaoShen\doc\自记帐\开发\银行电子回单测试表.pdf'
# pdf = PdfReader(open(pdf_file, 'rb'))
# pdf_num = len(pdf.pages)
# print(f"PDF Pages {pdf_num}.")
#
# #
# page = pdf.pages[1]
#
# # def page2image(page):
# #     pil_image = page.convert('RGB')
# #     image = Image.frombytes('RGB', pil_image.size, pil_image.stream.read())
# #
# #     return image
# #
# # image = page2image(page)

import fitz
from PIL import Image

# pdf_file = 'D:\Work\GaoShen\doc\自记帐\开发\银行电子回单测试表.pdf'
# pdf_file = 'D:\Work\GaoShen\doc\自记帐\测试数据\回单-中可-2401-全.pdf'
pdf_file = 'D:\Work\GaoShen\doc\自记帐\测试数据\回单-高琛-2401.pdf'

pdf = fitz.open(pdf_file)
# print(pdf.page_count)

# 平均分割 3 张
def split_image(image):
    width, height = image.size
    receipt_width = width
    receipt_height = height // 3
    print(receipt_height)

    receipt_images = []
    for i in range(3):
        left = 0
        top = i * receipt_height
        right = receipt_width
        bottom = top + receipt_height

        receipt_image = image.crop((left, top, right, bottom))
        receipt_images.append(receipt_image)

    return receipt_images

# 平均分割 2 张
def split_image3(image):
    width, height = image.size
    receipt_width = width
    receipt_height = height // 2
    print(receipt_height)

    receipt_images = []
    for i in range(2):
        left = 0
        top = i * receipt_height
        right = receipt_width
        bottom = top + receipt_height

        receipt_image = image.crop((left, top, right, bottom))
        receipt_images.append(receipt_image)

    return receipt_images

# 不规则分割
def split_image2(image):
    width, height = image.size
    receipt_width = width
    receipt_height = 215
    print(height)

    receipt_images = []
    for i in range(3):
        left = 0
        top = i * receipt_height
        right = receipt_width
        bottom = top + receipt_height

        receipt_image = image.crop((left, top, right, bottom))
        receipt_images.append(receipt_image)

    return receipt_images

for page_number in range(pdf.page_count):
    page = pdf.load_page(page_number)
    pix = page.get_pixmap()
    # print(pix.width)
    image = Image.frombytes("RGB", [pix.width, pix.height], pix.samples)

    #receipt_images = split_image(image)
    #receipt_images = split_image2(image)
    receipt_images = split_image3(image)
    i = 0
    for receipt_image in receipt_images:
        receipt_image.save(f"page_{page_number + 1}_{i}.jpg")
        i = i + 1
    # image.save(f"page_{page_number + 1}.jpg")