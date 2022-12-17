using System.Collections.Generic;
using Tactics.Util;
using Newtonsoft.Json;
using Tactics.Service.Model;
using Tactics.Domain.Interface.Board;
using Tactics.Domain.Interface.Unit;

namespace Tactics.Service {
    public class UnitService
    {
        private const string _testUnitName = "unit_test" + _json;
        private const string _json = ".json";
        private const string _unitFilePath = "Unit/";
        private static UnitService _instance;
        public static UnitService Instance {
            get {
                if(_instance == null) {
                    _instance = new UnitService();
                }
                return _instance;
            }
        }
        private UnitService() {
            
        }

        public List<IUnitDomain> GetTestBoard(IBoardDomain board) {
            var unitJson = FileReaderUtil.ReadFile(_unitFilePath, _testUnitName);
            var unitModel = JsonConvert.DeserializeObject<UnitSetModel>(unitJson);
            return unitModel.ToDomain(board);
        }
    }
}