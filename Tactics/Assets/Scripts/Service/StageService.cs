using Tactics.Domain;

namespace Tactics.Service {
    public class StageService
    {
        private static StageService _instance;
        public static StageService Instante {
            get {
                if(_instance == null) {
                    _instance = new StageService();
                }
                return _instance;
            }
        }
        private StageService() {

        }

        public Stage GetStage() {
            return null;
        }
    }
}