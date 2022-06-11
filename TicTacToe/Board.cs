namespace TicTacToo {
    // Game board class
    public class Board {
        private Stone[] _pieces;

        // Line pattern of win
        int[,] lineTable = new int[8, 3] { {0, 1, 2},{3, 4, 5},{6, 7, 8},{0, 3, 6},{1, 4, 7},{2, 5, 8},{0, 4, 8},{2, 4, 6},
        };

        // Constructor
        public Board() {
            _pieces = new Stone[3 * 3];

            // Board initialization
            _pieces = Enumerable.Repeat(new Stone(), 9).ToArray();
            _pieces = Enumerable.Repeat(Stone.Empty, 9).ToArray();
        }

        // Indexer of board    
        public Stone this[int index] {
            get { return _pieces[index]; }
            set { _pieces[index] = value; }
        }

        // Can put a stone
        public bool CanPut(int index) {
            return _pieces[index] == Stone.Empty;
        }

        // Check empty stone
        public bool IsComplete() {
            if (Judge() != Stone.Empty)
                return true;
            return this.GetSpaceIndexes().Count() == 0;
        }

        // Enumeration of empty stone
        public IEnumerable<int> GetSpaceIndexes() {
            return _pieces
            .Select((p, i) => new { Content = p, Index = i })
            .Where(o => o.Content == Stone.Empty)
            .Select(a => a.Index);
        }

        // Judgement for win
        public Stone Judge() {
            for (int i = 0; i < 8; i++) {
                int x = lineTable[i, 0];
                int y = lineTable[i, 1];
                int z = lineTable[i, 2];
                Stone stone = _pieces[x];
                if (stone != Stone.Empty && _pieces[y] == stone && _pieces[z] == stone)
                    return stone;
            }
            return Stone.Empty;
        }
    }
}
