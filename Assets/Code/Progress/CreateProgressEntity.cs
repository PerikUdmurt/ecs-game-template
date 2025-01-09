namespace Code.Progress
{
    public static class CreateProgressEntity
    {
        public static ProgressEntity Empty() =>
            Contexts.sharedInstance.progress.CreateEntity();
    }
}
