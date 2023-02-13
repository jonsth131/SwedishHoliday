module Tests

open System
open SwedishHoliday
open Xunit

[<Theory>]
[<InlineData(2001, 1, 1, true)>]
[<InlineData(2001, 1, 2, false)>]
[<InlineData(2001, 1, 6, true)>]
[<InlineData(2001, 2, 6, false)>]
let ``is january holiday`` (year, month, day, expected) =
    Assert.Equal(expected, Holiday.IsJanuaryHoliday(DateTime(year, month, day)))

[<Theory>]
[<InlineData(2001, 5, 1, true)>]
[<InlineData(2001, 5, 6, false)>]
[<InlineData(2001, 4, 1, false)>]
let ``is may holiday`` (year, month, day, expected) =
    Assert.Equal(expected, Holiday.IsMayHoliday(DateTime(year, month, day)))

[<Theory>]
[<InlineData(2001, 6, 6, true)>]
[<InlineData(2001, 6, 1, false)>]
[<InlineData(2001, 5, 6, false)>]
let ``is june holiday`` (year, month, day, expected) =
    Assert.Equal(expected, Holiday.IsJuneHoliday(DateTime(year, month, day)))

[<Theory>]
[<InlineData(2001, 12, 24, true)>]
[<InlineData(2001, 12, 25, true)>]
[<InlineData(2001, 12, 26, true)>]
[<InlineData(2001, 12, 31, true)>]
[<InlineData(2001, 12, 1, false)>]
[<InlineData(2001, 11, 24, false)>]
let ``is december holiday`` (year, month, day, expected) =
    Assert.Equal(expected, Holiday.IsDecemberHoliday(DateTime(year, month, day)))

[<Theory>]
[<InlineData(2020, 4, 9, false)>]
[<InlineData(2020, 4, 10, true)>]
[<InlineData(2020, 4, 13, true)>]
[<InlineData(2020, 5, 21, true)>]
[<InlineData(2002, 3, 29, true)>]
[<InlineData(2001, 4, 15, true)>]
[<InlineData(2002, 3, 31, true)>]
[<InlineData(2003, 4, 20, true)>]
[<InlineData(2004, 4, 11, true)>]
[<InlineData(2005, 3, 27, true)>]
[<InlineData(2006, 4, 16, true)>]
[<InlineData(2007, 4, 8, true)>]
[<InlineData(2008, 3, 23, true)>]
[<InlineData(2009, 4, 12, true)>]
[<InlineData(2010, 4, 4, true)>]
[<InlineData(2011, 4, 24, true)>]
[<InlineData(2012, 4, 8, true)>]
[<InlineData(2013, 3, 31, true)>]
[<InlineData(2014, 4, 20, true)>]
[<InlineData(2015, 4, 5, true)>]
[<InlineData(2016, 3, 27, true)>]
[<InlineData(2017, 4, 16, true)>]
[<InlineData(2018, 4, 1, true)>]
[<InlineData(2019, 4, 21, true)>]
[<InlineData(2020, 4, 12, true)>]
[<InlineData(2021, 4, 4, true)>]
[<InlineData(2022, 4, 17, true)>]
[<InlineData(2023, 4, 9, true)>]
[<InlineData(2024, 3, 31, true)>]
[<InlineData(2025, 4, 20, true)>]
[<InlineData(2026, 4, 5, true)>]
[<InlineData(2027, 3, 28, true)>]
[<InlineData(2028, 4, 16, true)>]
[<InlineData(2029, 4, 1, true)>]
let ``is easter holiday`` (year, month, day, expected) =
    Assert.Equal(expected, Holiday.IsEasterHoliday(DateTime(year, month, day)))

[<Theory>]
[<InlineData(2018, 6, 22, true)>]
[<InlineData(2018, 6, 23, true)>]
[<InlineData(2019, 6, 21, true)>]
[<InlineData(2019, 6, 22, true)>]
[<InlineData(2020, 6, 18, false)>]
[<InlineData(2020, 6, 19, true)>]
[<InlineData(2020, 6, 20, true)>]
[<InlineData(2020, 6, 21, false)>]
[<InlineData(2020, 6, 22, false)>]
[<InlineData(2020, 6, 23, false)>]
[<InlineData(2020, 6, 24, false)>]
[<InlineData(2020, 6, 25, false)>]
[<InlineData(2020, 6, 26, false)>]
[<InlineData(2020, 5, 26, false)>]
let ``is midsummer`` (year, month, day, expected) =
    Assert.Equal(expected, Holiday.IsMidsummer(DateTime(year, month, day)))

[<Theory>]
[<InlineData(2000, 11, 4, true)>]
[<InlineData(2001, 11, 3, true)>]
[<InlineData(2002, 11, 2, true)>]
[<InlineData(2003, 11, 1, true)>]
[<InlineData(2004, 11, 6, true)>]
[<InlineData(2005, 11, 5, true)>]
[<InlineData(2020, 10, 31, true)>]
[<InlineData(2020, 12, 1, false)>]
[<InlineData(2020, 9, 1, false)>]
let ``is all saints day`` (year, month, day, expected) =
    Assert.Equal(expected, Holiday.IsAllSaintsDay(DateTime(year, month, day)))

[<Theory>]
[<InlineData(2023, 1, 1)>]
[<InlineData(2023, 1, 6)>]
[<InlineData(2023, 4, 7)>]
[<InlineData(2023, 4, 9)>]
[<InlineData(2023, 4, 10)>]
[<InlineData(2023, 5, 1)>]
[<InlineData(2023, 5, 18)>]
[<InlineData(2023, 5, 28)>]
[<InlineData(2023, 6, 6)>]
[<InlineData(2023, 6, 23)>]
[<InlineData(2023, 11, 4)>]
[<InlineData(2023, 12, 24)>]
[<InlineData(2023, 12, 25)>]
[<InlineData(2023, 12, 26)>]
[<InlineData(2023, 12, 31)>]
let ``is swedish holiday`` (year, month, day) =
    Assert.True(Holiday.IsSwedishHoliday(DateTime(year, month, day)))
