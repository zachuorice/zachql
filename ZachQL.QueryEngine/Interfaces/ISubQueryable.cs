using ZachQL.QueryEngine.Interfaces;

// Classes implementing this are expected to support subqueries, 
// and will be responsible for handling the subquery appropriately for their semantics.
interface ISubQueryable {
    protected IQuery getSubquery();
    protected bool hasSubquery();
}