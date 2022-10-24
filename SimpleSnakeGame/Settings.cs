
namespace SimpleSnakeGame
{
    public class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static string direction;

        public Settings()
        {
            Width = 14;
            Height = 14;
            direction = "down";
        }
    }
}
