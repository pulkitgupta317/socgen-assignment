import pandas as pd
import datetime as dt

pd.options.mode.chained_assignment = None


def market_quote_evaluation():
    df = pd.read_csv('python_exercise_input_v2.csv', delimiter=';')

    # converting the string datetime to DateTime
    df['date'] = pd.to_datetime(df['date'])

    # To show the data of the input file seperated by ;
    market_quote_data = df.to_string(header=True, index=False, index_names=False).split('\n')
    [print(';'.join(record.split())) for record in market_quote_data]

    print()
    # Count by instruments, the number of quotes after 01/07/2020.
    threshold_date = dt.datetime(2020, 7, 1)
    df1 = df[df['date'] > threshold_date]
    print(df1.groupby(['instrument']).size())

    df1['date_evaluated'] = df1['date'].dt.date
    print()
    dict = {}

    for keys, group in df1.groupby(['instrument', 'date_evaluated']):
        if len(group) < 2 and keys[0] not in dict.keys():
            dict[keys[0]] = None
        else:
            min = group['value'].min()
            max = group['value'].max()
            dict[keys[0]] = [max - min, keys[1]]

    for i in dict.keys():
        if dict[i] is None:
            print(i, ': Missing market quotes!')
        else:
            print(i, ': spreadValue = ', dict[i][0], ' at ', dict[i][1].strftime('%d/%m/%Y'))


if __name__ == '__main__':
    market_quote_evaluation()