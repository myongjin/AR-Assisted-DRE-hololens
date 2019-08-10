public static class GameManager
{
    public static void AdvanceGameStage()
    {
        Game.Instance.GameStage = (GameStage)(((int)Game.Instance.GameStage + 1) % 3);
    }

    public static void SetAlignModelGameStage()
    {
        Game.Instance.GameStage = GameStage.AlignModel;
    }

    public static void SetStartTrainingGameStage()
    {
        Game.Instance.GameStage = GameStage.StartTraining;
        Game.Instance.DREStage = DREStage.Start;
    }
}
