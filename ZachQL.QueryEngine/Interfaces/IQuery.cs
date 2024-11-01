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