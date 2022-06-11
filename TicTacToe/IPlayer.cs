namespace TicTacToo {
    // Game player interface 
    public interface IPlayer {
        Stone Stone { get; }
        int MakeMove(Board board);
    }
}