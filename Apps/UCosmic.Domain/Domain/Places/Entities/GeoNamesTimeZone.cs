﻿namespace UCosmic.Domain.Places
{
    public class GeoNamesTimeZone : Entity
    {
        public string Id { get; protected internal set; }

        public double DstOffset { get; protected internal set; }
        public double GmtOffset { get; protected internal set; }

        public override string ToString()
        {
            return Id;
        }
    }
}