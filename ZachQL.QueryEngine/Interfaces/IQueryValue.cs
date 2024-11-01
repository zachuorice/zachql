namespace ZachQL.QueryEngine.Interfaces;

// Goals:
// - Support C# data type, leave transformation to binary up to the StorageEngine.
// - Support being defined through a subquery (?)
interface IQueryValue : ISubQueryable {
}