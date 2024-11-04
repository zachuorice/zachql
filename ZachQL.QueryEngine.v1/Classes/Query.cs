/*

ZachQL - A database you should not use.
Copyright (C) 2024  Zachary Tarvid-Richey <zr.public@gmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.

*/

using ZachQL.QueryEngine.Interfaces;

namespace ZachQL.QueryEngine.v1.Classes;

public class Query : IQuery {
    public enum QueryType {
        NOT_SET,
        SELECTING,
        INSERTING,
        UPDATING,
        DELETING
    }

    public class QueryTypeAlreadySet : Exception {}

    protected IQueryColumn[] selectColumns = [];
    protected IQueryTable[] fromDatabases = [];
    protected IQueryClause[] whereClauses = [];
    protected IQueryColumn[] orderColumns = [];
    protected IQueryColumn[] groupColumns = [];
    protected IQueryClause[] havingClauses = [];
    protected IQueryRow? values;
    protected uint offset = 0;
    protected uint limit = 0;
    protected QueryType queryType = QueryType.NOT_SET;

    protected void SetQueryType(QueryType type) {
        if(type == this.queryType) {
            return;
        }

        switch(this.queryType) {
            case QueryType.NOT_SET:
                this.queryType = type;
                break;
            default:
                throw new QueryTypeAlreadySet();
        }
    }

    public IQuery Select( IQueryColumn[] columns ) {
        this.SetQueryType(QueryType.SELECTING);
        this.selectColumns = columns;
        return this;
    }

    public IQuery From( IQueryTable[] databases ) {
        this.SetQueryType(QueryType.SELECTING);
        this.fromDatabases = databases;
        return this;
    }

    public IQuery Where( IQueryClause[] clauses ) {
        this.SetQueryType(QueryType.SELECTING);
        this.whereClauses = clauses;
        return this;
    }

    public IQuery OrderBy( IQueryColumn[] columns ) {
        this.SetQueryType(QueryType.SELECTING);
        this.orderColumns = columns;
        return this;
    }

    public IQuery GroupBy( IQueryColumn[] columns ) {
        this.SetQueryType(QueryType.SELECTING);
        this.groupColumns = columns;
        return this;
    }

    public IQuery Having( IQueryClause[] clauses ) {
        this.SetQueryType(QueryType.SELECTING);
        this.havingClauses = clauses;
        return this;
    }

    public IQuery Limit( uint count ) {
        this.limit = count;
        return this;
    }

    public IQuery Offset( uint count ) {
        this.offset = count;
        return this;
    }

    public IQuery Insert( IQueryTable table, IQueryRow values ) {
        this.SetQueryType(QueryType.INSERTING);
        this.fromDatabases = [table];
        this.values = values;
        return this;
    }

    public IQuery Update( IQueryTable table, IQueryRow values, IQueryClause[] clauses ) {
        this.SetQueryType(QueryType.UPDATING);
        this.fromDatabases = [table];
        this.values = values;
        this.whereClauses = clauses;
        return this;
    }

    public IQuery Delete( IQueryTable table, IQueryClause[] clauses ) {
        this.SetQueryType(QueryType.DELETING);
        this.fromDatabases = [table];
        this.whereClauses = clauses;
        return this;
    }


}
