import csv
from country import Country
from pprint import pprint


def read_from_file(_countries):
    global countries
    path = input("input path: ")
    try:
        countries = read(path)
        return read(path)
    except FileNotFoundError:
        print("File not found")
    except NameError:
        print("name is not defined")


def write_to_file(countries):
    path = input("input path: ")
    try:
        write(path, countries)
    except FileNotFoundError:
        print("File not found")
    except NameError:
        print("name is not defined")


def find_by_key(countries):
    key = input("input key: ")
    items = list(find(countries, key))
    if not items:
        print('No results')
        return
    return {x[0]: x[1] for x in items}


def sort_by_field(countries):

    field = input("input field: ")
    try:
        items = list(sort(countries, field))
        return {x[0]: x[1] for x in items}
    except AttributeError:
        print("No such attribute")


def read(path):
    countries = dict()

    with open(path, 'r') as file:
        reader = csv.reader(file)
        next(reader)
        for row in reader:
            countries[int(row[0])] = Country(row[1], row[2], row[3], row[4], row[5])

    return countries


def write(path, _countries):
    with open(path, 'w') as file:
        writer = csv.writer(file, delimiter=',')

        writer.writerow(['id', 'name', 'region', 'square', 'population', 'GDP'])

        for k, v in countries.items():
            writer.writerow([k, v.name, v.region, v.square, v.population, v.GDP])


def find(countries, key):
    return filter(lambda x: x[1].any_match(key), countries.items())


def sort(countries, field):
    return sorted(countries.items(), key=lambda x: getattr(x[1], field))


def add_country(countries):
    name = input("input name: ")
    region = input("input region: ")
    square = input("input square: ")
    population = input("input population: ")
    GDP = input("input GDP: ")

    country = Country(name, region, square, population, GDP)

    identifier = max(countries.keys()) + 1

    countries[identifier] = country

    return countries


def delete_country(countries):
    identifier = int(input("input id: "))
    del countries[identifier]

    return countries


def edit_country(countries):
    identifier = int(input("input id:"))
    field = input("input field: ")
    value = input("input new value: ")
    try:
        setattr(countries[identifier], field, value)
        return countries
    except AttributeError:
        print("No such attribute")
    except ValueError:
        print("Wrong value")


def print_countries(countries):
    if not countries:
        return
    print("id\tname\tregion\tsquare\tpopulation\tGDP")
    for k, v in countries.items():
        print("{}\t{}\t{}\t{}\t{}\t{}".format(k, v.name, v.region, v.square, v.population, v.GDP))


def print_menu():
    print('1 - read from file')
    print('2 - write to file')
    print('3 - find by key')
    print('4 - sort by field')
    print('5 - add_country')
    print('6 - delete_country')
    print('7 - edit_country')
    print('q - exit')


def show_menu(menu):
    while True:
        print_menu()
        key = input("choose option: ")

        if key == 'q':
            break

        try:
            print_countries(menu[key](countries))
        except KeyError:
            print("No such option")

        print()


# c = Country('Ukraine', 'Europe', 603628, 36000000, 3010)
# print(getattr(c, 'name'))
if __name__ == '__main__':
    countries = dict()
    menu = dict()

    menu['1'] = read_from_file
    menu['2'] = write_to_file
    menu['3'] = find_by_key
    menu['4'] = sort_by_field
    menu['5'] = add_country
    menu['6'] = delete_country
    menu['7'] = edit_country

    show_menu(menu)
