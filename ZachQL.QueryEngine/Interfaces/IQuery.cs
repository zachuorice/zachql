namespace ZachQL.QueryEngine.Interfaces;

/* 
 *   A naive interface for querying against our database. 
 *   The goal of this interface is to model SQL queries, ideally our lexer / parser will eventually use this.
 */
interface IQuery {
    public IQuery select( IQueryColumn[] columns );
    public IQuery from( IQueryTable[] databases );
    public IQuery where( IQueryClause[] clauses );
    public IQuery orderBy( IQueryColumn[] columns );
    public IQuery groupBy( IQueryColumn[] columns );
    public IQuery having( IQueryClause[] clauses );

    public IQuery insert( IQueryColumn[] columns, IQueryValue[] values );
    public IQuery update( IQueryColumn[] columns, IQueryValue[] values, IQueryClause[] clauses );

    public IQueryResult execute();
}