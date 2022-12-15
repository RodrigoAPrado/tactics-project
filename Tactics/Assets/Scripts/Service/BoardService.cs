using Tactics.Domain;
using Tactics.Util;
using Newtonsoft.Json;
using Tactics.Service.Model;
using Tactics.Domain.Interface.Board;

namespace Tactics.Service {
    public class BoardService
    {
        private const string _testBoardName = "board_test" + _json;
        private const string _json = ".json";
        private const string _boardFilePath = "Board/";
        private static BoardService _instance;
        public static BoardService Instance {
            get {
                if(_instance == null) {
                    _instance = new BoardService();
                }
                return _instance;
            }
        }
        private BoardService() {
            
        }

        public IBoardDomain GetBoard() {
            return null;
        }

        public IBoardDomain GetTestBoard() {
            var boardJson = FileReaderUtil.ReadFile(_boardFilePath, _testBoardName);
            var boardModel = JsonConvert.DeserializeObject<BoardModel>(boardJson);
            var domain = boardModel.ToDomain();
            domain.Init();
            return domain;
        }
    }
}