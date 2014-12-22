﻿/*
 * Copyright (C) 2012-2014 Arctium Emulation <http://arctium.org>
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Lappa_ORM;
using Lappa_ORM.Attributes;

namespace Framework.Database.Character.Entities
{
    public class CharacterTemplateData : Entity
    {
        [PrimaryKey]
        public byte ClassId { get; set; }
        public ushort MapId { get; set; }
        public ushort Zone  { get; set; }
        public float X      { get; set; }
        public float Y      { get; set; }
        public float Z      { get; set; }
        public float O      { get; set; }

        [ForeignKey("ClassId")]
        public virtual CharacterTemplateClass CharacterTemplateClass { get; set; }
    }
}
