public static class GameManager
{
    
    //public static int brothersRequestCount = 0;
    private static PlayerClass player = (new PlayerCreator()).getPlayer();
    public static double playerMoney = PlayerClass.currFunds;
    public static int nutritionScore = PlayerClass.totalNutrition;


    public static void ResetGame()
    {
        PlayerClass.currFunds = 50;
        // playerMoney = 50;
        // nutritionScore = 0;
        PlayerClass.totalNutrition = 0;
        //brothersRequestCount = 0;
    }

    public static double getMoney()
    {
        return PlayerClass.currFunds;
    }

    public static int getScore()
    {
        return PlayerClass.totalNutrition;
    }
}