namespace TicTacToo {
    // Main entry point class
    class Program {
        // Main
        static void Main(string[] args) {
            var controller = new GameController();
            while (true) {
                controller.Run();
                if (!GameController.Confirm("Try Again?(y/n):"))
                    break;
            }
        }
    }
}
