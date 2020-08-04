namespace Tennis
{
    // changes class to public
    public class TennisGame : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (m_score1 == m_score2)
            {
                switch (m_score1)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                score = DetermineWinner(m_score1, m_score2);
            }
            else
            {
                CalculateScore(ref score, ref tempScore);
            }
            return score;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="score"></param>
        /// <param name="tempScore"></param>
       
        //created new method called clculate score
        private void CalculateScore(ref string score, ref int tempScore)
        {
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = m_score1;
                else { score += "-"; tempScore = m_score2; }
                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }
        }
        //created new meothed determine the winner and made code more readable
        private string DetermineWinner(int score1, int score2)
        {
            string score;
            var minusResult = score1 - score2;
            if (minusResult == 1) {
                score = "Advantage player1";
            }
            else if (minusResult == -1)
            {
                score = "Advantage player2";
            }
            else if(minusResult >= 2)
            {
                score = "Win for player1";
            }
            else 
            { 
                score = "Win for player2";
            }
            return score;
        }
    }
}

