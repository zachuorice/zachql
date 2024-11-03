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

interface ITypedValue<T> {
    T GetValue();
    T SetValue(T value);
    uint GetLength();
    void SetLength(uint length);
}