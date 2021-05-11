import LangHandler from './resource';

export default langHandler => ({
    months: [
        LangHandler(langHandler, 'Jan'), LangHandler(langHandler, 'Feb'),
        LangHandler(langHandler, 'Mar'), LangHandler(langHandler, 'Apr'),
        LangHandler(langHandler, 'May'), LangHandler(langHandler, 'Jun'),
        LangHandler(langHandler, 'Jul'), LangHandler(langHandler, 'Aug'),
        LangHandler(langHandler, 'Sep'), LangHandler(langHandler, 'Oct'),
        LangHandler(langHandler, 'Nov'), LangHandler(langHandler, 'Dec')
    ],

    weekdays: [
        LangHandler(langHandler, 'Su'), LangHandler(langHandler, 'Mo'),
        LangHandler(langHandler, 'Tu'), LangHandler(langHandler, 'We'),
        LangHandler(langHandler, 'Th'), LangHandler(langHandler, 'Fr'),
        LangHandler(langHandler, 'Sa')
    ]
})
