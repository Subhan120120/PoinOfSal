using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class Add_procedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createProcSql = @"Create PROCEDURE [dbo].[GetNextDocNum] @ProcessCode nvarchar(5), @ColumnName nvarchar(30), @TableName nvarchar(30)
									AS
									BEGIN
										DECLARE @LastNumber int = (select ISNULL(LastNumber,0) from DcProcesses where ProcessCode = @ProcessCode)
										DECLARE @DocCount int = 1	
										
										WHILE ( @DocCount = 1)
										BEGIN
											IF (@LastNumber is null or @LastNumber = '') 
												SET @LastNumber = 0
											SET @LastNumber = @LastNumber + 1
									
											DECLARE @NextDoc nvarchar(50) = @ProcessCode + '-' + Convert(nvarchar, @LastNumber)
											
											DECLARE @QryDocCount nvarchar(500) = 'select @DocNum = count(1) from '+@TableName+' where '+@ColumnName+' = '''+@NextDoc+''''
											
											EXEC sp_executesql @QryDocCount, N'@DocNum int OUTPUT', @DocCount OUTPUT
									
										END
										SELECT @NextDoc AS Value
										UPDATE DcProcesses SET LastNumber = @LastNumber WHERE ProcessCode = @ProcessCode
									END";
            migrationBuilder.Sql(createProcSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropProcSql = "DROP PROC GetNextDocNum";
            migrationBuilder.Sql(dropProcSql);
        }
    }
}
