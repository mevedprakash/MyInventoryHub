import 'primevue/resources/themes/saga-blue/theme.css'       //theme
import 'primevue/resources/primevue.min.css'                 //core css
import 'primeicons/primeicons.css'                           //icons
import PrimeVue from 'primevue/config';
import Accordion from 'primevue/accordion';
import AccordionTab from 'primevue/accordiontab';
export default function (app) {
    console.log("in PrimeVue", app);
    app.use(PrimeVue);
    app.component('Accordion', Accordion);
    app.component('AccordionTab', AccordionTab);
}