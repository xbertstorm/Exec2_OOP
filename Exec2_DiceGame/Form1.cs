namespace Exec2_DiceGame
{
    public partial class Form1 : Form
    {
        private DiceGame game;
        public Form1()
        {
            InitializeComponent();
            label1.Text = String.Empty;
            label2.Text = String.Empty;
            game = new DiceGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.Check(game.NewGame());
            label1.Text = game.DisplayNewGameSetUp();
            label2.Text = game.DisplayGameScore();
        }
    }
    public class DiceGame
	{
		private int[] uncheck = new int[4];
		private string result = string.Empty;
		private Random random = new Random();
		public int[] NewGame()
		{
			do
			{
				uncheck = new int[4] { random.Next(1, 7), random.Next(1,7),random.Next(1,7),random.Next(1,7)};
			}
			while (uncheck[0] != uncheck[1] && uncheck[0] != uncheck[2] && uncheck[0] != uncheck[3] && uncheck[1] != uncheck[2] && uncheck[1] != uncheck[3] && uncheck[2] != uncheck[3]);
			return uncheck;
		}
		public string DisplayNewGameSetUp()
		{

			return $"{uncheck[0].ToString()} - {uncheck[1].ToString()} - {uncheck[2].ToString()} - {uncheck[3].ToString()}";
		}
		public string DisplayGameScore()
		{
			return this.result;
		}
		public void Check(int[] set)
		{
			Array.Sort(set);
			int[] result = new int[3];
			int resulttag = 0;

			for (int i = 0; i < set.Length - 1; i++)
			{
				result[i] = set[i] * 10 + set[i + 1];
			}

			if (result[0] % 11 == 0) resulttag = 1;
			else if (result[1] % 11 == 0) resulttag = 2;
			else if (result[2] % 11 == 0) resulttag = 3;

			switch (resulttag)
			{
				case 1:
					this.result = $"得分是{uncheck[2] + uncheck[3]}";
					break;
				case 2:
					this.result = $"得分是{uncheck[0] + uncheck[3]}";
					break;
				case 3:
					this.result = $"得分是{uncheck[0] + uncheck[1]}";
					break;
			}
		}
	}
}