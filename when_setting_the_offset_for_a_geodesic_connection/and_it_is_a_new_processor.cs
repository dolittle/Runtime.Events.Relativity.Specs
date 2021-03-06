// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Machine.Specifications;

namespace Dolittle.Runtime.Events.Relativity.Specs.when_setting_the_offset_for_a_geodesic_connection
{
    [Subject(typeof(IGeodesics), nameof(IGeodesics.SetOffset))]
    public class and_it_is_a_new_processor : given.a_geodesics
    {
        static IGeodesics geodesics;
        static ulong last_processed;
        static EventHorizonKey event_horizon;

        Establish context = () =>
        {
            last_processed = 100;
            event_horizon = get_event_horizon_key();
            geodesics = get_geodesics();
        };

        Because of = () => geodesics.SetOffset(event_horizon, last_processed);

        It should_set_the_last_processed_version_for_the_processor = () => geodesics.GetOffset(event_horizon).ShouldEqual(last_processed);
    }
}