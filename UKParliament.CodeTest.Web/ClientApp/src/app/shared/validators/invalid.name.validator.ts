import { FormControl, ValidationErrors } from '@angular/forms';

export class InvalidNameValidator {

    static invalidName(control: FormControl): ValidationErrors | null {

        const invalidNames: string[] = ['test'];

        if (invalidNames.some(inv => control.value.indexOf(inv) > -1))
            return { "invalidName": true };

        return null;
    }
}