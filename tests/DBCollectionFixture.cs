namespace DBDockerIntegrationTests;

[CollectionDefinition(nameof(DBCollectionFixture))]
public class DBCollectionFixture : ICollectionFixture<DbFixture> { }
