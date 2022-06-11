namespace TicTacToo {
    //Stone type definition class
    public class Stone {
        public static readonly Stone Batu = new Stone { Value = 'X' };
        public static readonly Stone Maru = new Stone { Value = 'O' };
        public static readonly Stone Empty = new Stone { Value = '.' };

        public char Value { get; private set; }
    }
}