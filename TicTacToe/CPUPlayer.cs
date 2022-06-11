namespace TicTacToo {
    // CPU player class
    public class CPUPlayer : IPlayer {
        public Stone Stone { get; private set; }

        // Constructor
        public CPUPlayer(Stone myStone) {
            Stone = myStone;
        }

        // Next move of game
        public int MakeMove(Board board) {
            var (place, winner) = BestMove(board, Stone);
            board[place] = Stone;
            return place;
        }

        // Return the next player
        private Stone NextPlayer(Stone now) {
            return now == Stone.Batu ? Stone.Maru : Stone.Batu;
        }

        private (int, Stone) BestMove(Board board, Stone player, int level = 0) {
            var opponent = NextPlayer(player);
            if (board.IsComplete())
                // draw
                return (-1, Stone.Empty);

            foreach (var ix in board.GetSpaceIndexes()) {
                board[ix] = player;
                try {
                    if (board.Judge() == player)
                        // win
                        return (ix, player);
                } finally {
                    board[ix] = Stone.Empty;
                }
            }
            // random
            return (RandomElementAt(board.GetSpaceIndexes()), opponent);
        }

        // Random pickup
        private T RandomElementAt<T>(IEnumerable<T> ie){
            Random _Rand = new Random();
            return ie.ElementAt(_Rand.Next(ie.Count()));
        }
    }
}
