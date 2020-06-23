from enum import Enum, unique


@unique
class Region(Enum):
    Europe = 1
    North_America = 2
    South_America = 3
    Africa = 4
    Asia = 5
    Australia = 6
    Oceania = 7
    Other = 8
