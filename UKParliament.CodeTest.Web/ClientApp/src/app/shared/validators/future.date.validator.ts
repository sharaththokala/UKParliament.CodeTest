import { FormControl, ValidationErrors } from '@angular/forms';

export class FutureDateValidator {

    static greaterThanToday(control: FormControl): ValidationErrors | null {
        const today: Date = new Date();

        if (new Date(control.value) > today)
            return { "greaterThanToday": true };

        return null;
    }
}