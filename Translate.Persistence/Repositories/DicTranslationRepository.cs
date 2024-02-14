using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System.Text.Json;
using Translate.Application.Contracts.Persistence;
using Translate.Application.Features.Translate.Queries.GetTranslates;
using Translate.Application.Features.Translate.Queries.GetTranslateTables;


namespace Translate.Persistence.Repositories
{
    public class DicTranslationRepository : GenericRepository<DicTranslationDto>, IDicTranslationRepository
    {
        public DicTranslationRepository(TranslateDataContext context): base(context) 
        {           

        }       

        public async Task<List<DicTranslationDto>> GetTranslations(string tableName, int tableTypeCode, int statusCode,
                int pageIndex, int pageSize)
        {
 
            string _tableName = tableName;
            int _tableTypeCode = tableTypeCode;
            int _statusCode = statusCode;
            int _pageIndex = pageIndex;
            int _pageSize = pageSize;
                
            switch(tableName)
            {
                case "All":
                   return  await  GetAllTablesTranslation(_pageIndex,_pageSize);
                    //break;

                default:
                  return  await GetFilteredTablesTranslation(_tableName,_pageIndex,_pageSize);
                    //break;

            }             


        }

        private async Task<List<DicTranslationDto>> GetFilteredTablesTranslation(string tableName,int index,int size)
        {
                var result = await(from translate in this._context.DicTranslations
                                   join language in this._context.Languages on translate.LanguageCode equals language.LanguageCode
                                   join tableType in this._context.TableTypes on translate.TableTypeCode equals tableType.Code
                                   join unitType in this._context.UnitTypes on new { code = translate.TableCode, name = translate.TableName } equals new { code = unitType.UnitTypeCode, name = "UnitType" } into unitTypeGroup
                                   from unitType in unitTypeGroup.DefaultIfEmpty()
                                   join activityStatus in this._context.DicActivityStatuses on new { code = translate.TableCode, name = translate.TableName } equals new { code = (int)activityStatus.Status, name = "DIC_ActivityStatus" } into activityStatusGroup
                                   from activityStatus in activityStatusGroup.DefaultIfEmpty()
                                   join agreementType in this._context.DicAgreementTypes on new { code = translate.TableCode, name = translate.TableName } equals new { code = (int)agreementType.AgreementTypeId, name = "DIC_AgreementTypes" } into agreementGroup
                                   from agreementType in agreementGroup.DefaultIfEmpty()
                                   join dept in this._context.Depts on new { code = translate.TableCode, name = translate.TableName } equals new { code = dept.DeptCode, name = "Dept" } into deptGroup
                                   from dept in deptGroup.DefaultIfEmpty()
                                   join yesAndNo in this._context.DicYesAndNos on new { code = translate.TableCode, name = translate.TableName } equals new { code = yesAndNo.Id, name = "yesAndNo" } into yesAndNoGroup
                                   from yesAndNo in yesAndNoGroup.DefaultIfEmpty()
                                   where translate.TableName == tableName

                                   select new DicTranslationDto
                                   {
                                       Id = translate.Id,
                                       TableName = translate.TableName,
                                       TableCode = translate.TableCode,
                                       Translate = translate.Translate == null ? "" : translate.Translate,
                                       TableTypeCode = tableType.Code,
                                       UnitType = (unitType == null ? "" : unitType.UnitTypeName),
                                       UnitTypeTimestamp = unitType == null ? "" : Convert.ToBase64String(unitType.TimeStamp),
                                       ActivityStatus = (activityStatus.StatusDescription == null ? "" : activityStatus.StatusDescription),
                                       ActivityStatusTimestamp = activityStatus.StatusDescription == null ? "" : Convert.ToBase64String(activityStatus.TimeStamp),
                                       AgreementType = (agreementType == null ? "" : agreementType.AgreementTypeDescription),
                                       AgreementTypeTimestamp = agreementType == null ? "" : Convert.ToBase64String(agreementType.TimeStamp),
                                       DeptName = (dept == null ? "" : dept.DeptName),
                                       DeptTimestamp = dept == null ? "" : Convert.ToBase64String(dept.TimeStamp),
                                       LanguageDescription = language.LanguageDescription,
                                       LastUpdate = translate.LastUpdate,
                                       TotalCount = (from translate in this._context.DicTranslations
                                                     join language in this._context.Languages on translate.LanguageCode equals language.LanguageCode
                                                     select translate.Id).ToList().Count

                                   }).OrderBy(row => row.Id).Skip(index * size).Take(size).ToListAsync();
                return result;

            

        }

        private async Task<List<DicTranslationDto>> GetAllTablesTranslation(int index,int size)
        {
            var result = await(from translate in this._context.DicTranslations
                               join language in this._context.Languages on translate.LanguageCode equals language.LanguageCode
                               join tableType in this._context.TableTypes on translate.TableTypeCode equals tableType.Code
                               join unitType in this._context.UnitTypes on new { code = translate.TableCode, name = translate.TableName } equals new { code = unitType.UnitTypeCode, name = "UnitType" } into unitTypeGroup
                               from unitType in unitTypeGroup.DefaultIfEmpty()
                               join activityStatus in this._context.DicActivityStatuses on new { code = translate.TableCode, name = translate.TableName } equals new { code = (int)activityStatus.Status, name = "DIC_ActivityStatus" } into activityStatusGroup
                               from activityStatus in activityStatusGroup.DefaultIfEmpty()
                               join agreementType in this._context.DicAgreementTypes on new { code = translate.TableCode, name = translate.TableName } equals new { code = (int)agreementType.AgreementTypeId, name = "DIC_AgreementTypes" } into agreementGroup
                               from agreementType in agreementGroup.DefaultIfEmpty()
                               join dept in this._context.Depts on new { code = translate.TableCode, name = translate.TableName } equals new { code = dept.DeptCode, name = "Dept" } into deptGroup
                               from dept in deptGroup.DefaultIfEmpty()
                               join yesAndNo in this._context.DicYesAndNos on new { code = translate.TableCode, name = translate.TableName } equals new { code = yesAndNo.Id, name = "yesAndNo" } into yesAndNoGroup
                               from yesAndNo in yesAndNoGroup.DefaultIfEmpty()

                               select new DicTranslationDto()
                               {
                                   Id = translate.Id,
                                   TableName = translate.TableName,
                                   TableCode = translate.TableCode,
                                   Translate = translate.Translate == null ? "" : translate.Translate,
                                   TableTypeCode = tableType.Code,
                                   UnitType = (unitType == null ? "" : unitType.UnitTypeName),
                                   UnitTypeTimestamp = unitType == null ? "" : Convert.ToBase64String(unitType.TimeStamp),
                                   ActivityStatus = (activityStatus.StatusDescription == null ? "" : activityStatus.StatusDescription),
                                   ActivityStatusTimestamp = activityStatus.StatusDescription == null ? "" : Convert.ToBase64String(activityStatus.TimeStamp),
                                   AgreementType = (agreementType == null ? "" : agreementType.AgreementTypeDescription),
                                   AgreementTypeTimestamp = agreementType == null ? "" : Convert.ToBase64String(agreementType.TimeStamp),
                                   DeptName = (dept == null ? "" : dept.DeptName),
                                   DeptTimestamp = dept == null ? "" : Convert.ToBase64String(dept.TimeStamp),
                                   LanguageDescription = language.LanguageDescription,
                                   LastUpdate = translate.LastUpdate,
                                   TotalCount = (from translate in this._context.DicTranslations
                                                 join language in this._context.Languages on translate.LanguageCode equals language.LanguageCode
                                                 select translate.Id).ToList().Count


                               }).OrderBy(row => row.Id).Skip(index * size).Take(size).ToListAsync();
            return result;

        }
    }
}
