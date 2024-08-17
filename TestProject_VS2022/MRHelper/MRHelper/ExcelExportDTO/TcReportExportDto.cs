using MRHelper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRHelper.ExcelExportDTO
{
    /// <summary>
    /// 总分公司数据源主数据处理后导出 DTO
    /// </summary>
    public class TcReportExportDto
    {
        // 说明：
        // 1. 是 public 类型
        // 2. 用在 Excel 模板中
        public List<TcReportEntity> ExportDtoList { get; set; }

        public TcReportExportDto()
        {

        }

        public TcReportExportDto(List<TcReportEntity> dataDetails)
        {
            ExportDtoList = dataDetails;
        }
    }
}
