// Observer Pattern
// Copyright (C) 2022 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;

namespace ObserverPattern._04_UseDelegates
{
    public class EventBase<TData>
    {
        private readonly List<EventHandlerDelegate<TData>> subscribers = new();

        public void Subscribe(EventHandlerDelegate<TData> subscriber)
        {
            if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));

            subscribers.Add(subscriber);
        }

        public void Unsubscribe(EventHandlerDelegate<TData> subscriber)
        {
            if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));

            subscribers.Remove(subscriber);
        }

        public void Notify(TData data)
        {
            foreach (EventHandlerDelegate<TData> subscriber in subscribers)
                subscriber(data);
        }
    }
}