from region import Region


class Country:

    def __init__(self, name='a', region='Other', square=0, population=0, GDP=0):
        self.name = name
        self.region = region
        self.square = square
        self.population = population
        self.GDP = GDP

    def any_match(self, key):
        return key in str(self.__repr__)

    def __str__(self):
        return 'Country: {}, ' \
               'region: {}, square: {}, ' \
               'population: {}, ' \
               'GDP: {}'.format(self.name, self.region,
                                self.square,
                                self.population, self.GDP)

    def __repr__(self):
        return self.name + ',' + self.region + ',' + \
               str(self.square) + ',' + str(self.population) + ',' + str(self.GDP)

    @property
    def name(self):
        return self._name

    @name.setter
    def name(self, value):
        if not value and not value.isalpha():
            raise ValueError("incorrect name")
        self._name = value

    @property
    def region(self):
        return self._region

    @region.setter
    def region(self, value):
        if value not in Region.__members__:
            raise ValueError("incorrect region")
        self._region = value

    @property
    def square(self):
        return self._square

    @square.setter
    def square(self, value):
        if value is not int and int(value) < 0:
            raise ValueError("incorrect square")
        self._square = int(value)

    @property
    def population(self):
        return self._population

    @population.setter
    def population(self, value):
        if value is not int and int(value) < 0:
            raise ValueError("incorrect population")
        self._population = value

    @property
    def GDP(self):
        return self._GDP

    @GDP.setter
    def GDP(self, value):
        if value is not int and int(value) < 0:
            raise ValueError("incorrect GDP")
        self._GDP = value



