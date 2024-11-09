'use client';

import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { Button } from '@/components/ui/button';
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from '@/components/ui/select';
import { Poll } from '@/models/poll.model';

import { DialogFooter, DialogClose } from '@/components/ui/dialog';

const formSchema = z.object({
  email: z.string().email('Please provide a valid email'),
  option: z.string().min(1, { message: 'Please choose an option to vote' })
});

export function VoteForm({ poll }: { poll: Poll }) {
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      email: '',
      option: ''
    }
  });

  function onSubmit(values: z.infer<typeof formSchema>) {
    console.log(values);
  }

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-8">
        <FormField
          control={form.control}
          name="email"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Email</FormLabel>
              <FormControl>
                <Input placeholder="Email*" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="option"
          render={({ field }) => {
            return (
              <FormItem>
                <FormLabel>Options</FormLabel>
                <Select onValueChange={field.onChange} defaultValue={field.value} {...field}>
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Option" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    {poll.options.map((option) => {
                      return (
                        <SelectItem key={option.id} value={option.name}>
                          {option.name}
                        </SelectItem>
                      );
                    })}
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            );
          }}
        />
        <DialogFooter className="sm:justify-end">
          <DialogClose asChild>
            <Button type="button" variant="secondary">
              Close
            </Button>
          </DialogClose>

          <Button type="submit">Save</Button>
        </DialogFooter>
      </form>
    </Form>
  );
}
