using MRHelper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRHelper.ExcelExportDTO
{
    // 可以在这些 Dto 类中，对数据作进一步处理，比如添加报表制作人等等属性

    /// <summary>
    /// 主数据处理后导出 DTO
    /// </summary>
    public class ZqReportExportDto
    {
        // 说明：
        // 1. 是 public 类型
        // 2. 用在 Excel 模板中
        public List<ZqReportEntity> ExportDtoList { get; set; }

        public ZqReportExportDto()
        {

        }

        public ZqReportExportDto(List<ZqReportEntity> dataDetails)
        {
            ExportDtoList = dataDetails;
        }
    }

    /// <summary>
    /// 银行账号/法人代表账期汇总金额导出 DTO
    /// </summary>
    public class ZqCollectExportDto
    {
        public List<ZqReport4BankCashEntity> ExportDtoList { get; set; }

        public ZqCollectExportDto()
        {

        }

        public ZqCollectExportDto(List<ZqReport4BankCashEntity> dataDetails)
        {
            ExportDtoList = dataDetails;
        }
    }
}
