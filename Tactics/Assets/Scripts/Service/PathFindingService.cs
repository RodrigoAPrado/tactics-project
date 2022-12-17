namespace Tactics.Service {
    public class PathFindingService {
        
        private static PathFindingService _instance;
        public static PathFindingService Instance {
            get {
                if(_instance == null) {
                    _instance = new PathFindingService();
                }
                return _instance;
            }
        }

        private PathFindingService() {
            
        }
    }
}