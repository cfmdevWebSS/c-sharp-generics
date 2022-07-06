namespace WiredBrainCoffee.StorageApp.Repositories
{
    public static class RepositoryExtensions
    {
        //non generic version of AddBatch...
        public static void AddBatch<T>(this IWriteRepository<T> organizationRepository, T[] organizations)
        {
            foreach (var item in organizations)
            {
                organizationRepository.Add(item);
            }
            organizationRepository.Save();
        }
    }
}
