Crea un componente frontend in React usando Material UI con best practice
"Scrivi un componente React usando Material UI che rispetti tutte le seguenti best practice:

Uso corretto di MUI

Usa componenti MUI nativi (TextField, Button, Box, Typography, ecc.)

Usa il sistema sx per lo styling inline (evita style e className non MUI)

Applica il tema MUI corrente (colori, spaziature, tipografia)

Gestione dello stato e dei dati

Usa useState, useEffect, useReducer o React Query (se richiesto) per gestire lo stato locale o asincrono

Evita di mischiare logica e presentazione (separa componenti "smart" e "dumb" se necessario)

Accessibilità (a11y)

Usa elementi semantici (label, aria-*, role)

Assicurati che i form siano accessibili con tastiera e screen reader

Usa le proprietà aria-label o aria-describedby per descrivere elementi interattivi

Gestione dei form (se presenti)

Usa TextField, Select, Checkbox, ecc. con onChange, value e error per la validazione

Mostra errori di validazione in modo chiaro sotto i campi

(Bonus) Usa react-hook-form con MUI Controller per una gestione avanzata

Pulizia e leggibilità del codice

Funzioni componenti nominate e modulari

JSX leggibile, con props ben indentate

Separazione tra logica e markup dove possibile

Commenti solo dove servono (non abusare)

Responsività e layout

Usa il sistema Grid, Box, Stack o Container di MUI per layout responsive

Evita media query manuali se puoi usare le API sx responsive di MUI ({ xs: 'block', md: 'flex' })

Comunicazione con backend/API

Usa fetch, axios o React Query in useEffect o handler asincroni

Gestisci loading, errori e stati vuoti in modo chiaro

Usa indicatori MUI come CircularProgress, Alert, Skeleton

Componenti riutilizzabili e coerenti

Se un componente è generico, estrailo in un file separato (/components/common/)

Usa nomi chiari e consistenti (SkillForm, SkillList, SkillCard)

Mantieni consistenza tra i componenti (es. padding, larghezza, spacing)

Testing (facoltativo)

Il componente deve essere testabile (es. con data-testid, props isolate)

Non deve dipendere da variabili globali non controllabili

Tema e personalizzazione

Rispetta il tema globale MUI (ThemeProvider)

Usa palette, typography, spacing definiti nel tema

Non usare librerie grafiche esterne non necessarie. Tutto il layout, gli elementi UI e la logica visiva devono essere basati su Material UI e React."

